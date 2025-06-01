# SPDX-FileCopyrightText: 2025 chronovore/legiayayana
#
# SPDX-License-Identifier: Apache-2.0

project('binjaarch64', 'c')

BINJA_API_SOURCE='binaryninja-api/arch/arm64/'

shared_library('binjaarch64', [
	BINJA_API_SOURCE + 'disassembler/decode.c',
	BINJA_API_SOURCE + 'disassembler/format.c',
	BINJA_API_SOURCE + 'disassembler/sysregs_gen.c',
	BINJA_API_SOURCE + 'disassembler/sysregs_fmt_gen.c',
	BINJA_API_SOURCE + 'disassembler/regs.c',
	BINJA_API_SOURCE + 'disassembler/encodings_dec.c',
	BINJA_API_SOURCE + 'disassembler/encodings_fmt.c',
	BINJA_API_SOURCE + 'disassembler/operations.c',
	BINJA_API_SOURCE + 'disassembler/pcode.c',
	BINJA_API_SOURCE + 'disassembler/decode0.c',
	BINJA_API_SOURCE + 'disassembler/decode1.c',
	BINJA_API_SOURCE + 'disassembler/decode2.c',
	BINJA_API_SOURCE + 'disassembler/decode_fields32.c',
	BINJA_API_SOURCE + 'disassembler/decode_scratchpad.c'
], vs_module_defs: 'binjaarch64.def')
